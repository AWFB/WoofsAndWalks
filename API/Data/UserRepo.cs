using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepo : IUserRepo
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRepo(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public void Update(AppUser user)
    {
        // for EF tracking - Not saved at this point
        _context.Entry(user).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users
            .Include(p => p.Photos) // include related photo entity
            .ToListAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<AppUser> GetUserByUserNameAsync(string username)
    {
        return await _context.Users
            .Include(p => p.Photos) // include related photo entity
            .SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await _context.Users
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync(); // return list of member Dtos

    }

    public async Task<MemberDto> GetMemberAsync(string username)
    {
        return await _context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        
        // replaced with automapper
        // .Select(user => new MemberDto
        // {
        //     Id = user.Id,
        //     UserName = user.UserName,
        //     KnownAs = user.KnownAs
        // }).SingleOrDefaultAsync();
    }
}