
using Nusuk.Core.Interfaces;
using Nusuk.Infrastructure.Data;
using Nusuk.Services.Otp;

namespace Nusuk.Infrastructure.Repositories;

public class UserOtpRepository(NusukDbContext _context) : BaseRepository<UserOtp>(_context), IUserOtpRepository
{

}
