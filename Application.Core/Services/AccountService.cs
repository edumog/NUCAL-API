using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.DTOs.Account;
using NUCAL.Application.Core.Entities;
using NUCAL.Application.Core.Helpers;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Application.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccount account;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IAccount account, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.account = account;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseItemDTO<AccountResultDTO>> CreateUser(UserCreationDTO user)
        {
            ResponseItemDTO<AccountResultDTO> response;
            bool userCreationFlag = false;
            try
            {
                response = await RegisterOnSecurityDatabase(user, user.KeepLoggedIn);
                userCreationFlag = true;
                response = await RegisterOnApplicatonDatabase(user, response);
                return response;
            }
            catch (Exception exception)
            {
                RestoreDBs(user.Email, userCreationFlag);
                return mapper.MapResponseDTOToResponseItemDTO<AccountResultDTO>(ExceptionHandler.GetResult(exception));
            }
        }

        private async Task<ResponseItemDTO<AccountResultDTO>> RegisterOnSecurityDatabase(UserCreationDTO user, bool KeepLoggedIn)
        {
            UserSecurityDTO userSecurity = mapper.Map<UserCreationDTO, UserSecurityDTO>(user);
            ResponseItemDTO<AccountResultDTO> result = await account.CreateUser(userSecurity, KeepLoggedIn);
            return result;
        }
        private async Task<ResponseItemDTO<AccountResultDTO>> RegisterOnApplicatonDatabase(UserCreationDTO user, ResponseItemDTO<AccountResultDTO> response)
        {
            User userDb = await unitOfWork.UsersRepository.GetByEmail(user.Email);
            if (response.Succeeded && userDb != null)
            {
                unitOfWork.UsersRepository.Delete(userDb);
                unitOfWork.commit();
                response.StatusCode = 400;
            }
            if (response.Succeeded)
            {
                userDb = mapper.Map<UserCreationDTO, User>(user);
                userDb.Id = response.Item.User.Id;
                userDb = await unitOfWork.UsersRepository.Add(userDb);
                unitOfWork.commit();
                response.Item.User = Merger.MergeUserResponseAndUserDb(response.Item.User, userDb);
                response.StatusCode = 200;
            }
            return response;
        }
        private void RestoreDBs(string userEmail, bool userCreationFlag)
        {
            if (userCreationFlag)
            {
                account.RemoveUser(userEmail);
            }
        }

        public async Task<ResponseItemDTO<AccountResultDTO>> Login(LoginDTO credentials)
        {
            try
            {
                ResponseItemDTO<AccountResultDTO> response = await account.Login(credentials);
                if (response.Succeeded)
                {
                    response = await ValidateUserFromDb(response);
                }
                return response;
            }
            catch (Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<AccountResultDTO>(ExceptionHandler.GetResult(exception));
            }
        }

        private async Task<ResponseItemDTO<AccountResultDTO>> ValidateUserFromDb(ResponseItemDTO<AccountResultDTO> response)
        {
            User userDb = await unitOfWork.UsersRepository.GetEntityById(response.Item.User.Id);

            if (userDb == null)
            {
                response.StatusCode = 400;
                response.Succeeded = false;
                RestoreDBs(response.Item.User.Email, true);
            }
            else
            {
                response.Item.User = Merger.MergeUserResponseAndUserDb(response.Item.User, userDb);
                response.StatusCode = 200;
            }
            return response;
        }

        public async Task<ResponseItemDTO<RefreshTokenResponseDTO>> RefreshToken(string currentToken, string idUser)
        {
            try
            {
                var response = await account.RefreshToken(currentToken, idUser);
                if((response.Succeeded && response.Item != null) || (!response.Succeeded))
                    return response;
                else
                {
                    response.Succeeded = false;
                    response.StatusCode = 400;
                    return response;
                }
            }
            catch (Exception exception)
            {
                return mapper.MapResponseDTOToResponseItemDTO<RefreshTokenResponseDTO>(ExceptionHandler.GetResult(exception));
            }
        }
    }
}
