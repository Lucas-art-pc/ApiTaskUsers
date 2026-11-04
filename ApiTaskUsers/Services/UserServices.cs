using ApiTaskUsers.Data;
using ApiTaskUsers.Data.Dtos.Users;
using ApiTaskUsers.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiTaskUsers.Services;

public class UserServices(IMapper mapper, AppDbContext context)
{
    private readonly IMapper _mappper = mapper;
    private readonly AppDbContext _context = context;

    public async Task<ReadUserDto> CreateUser(CreateUserDto createUserDto)
    {
        var user = _mappper.Map<User>(createUserDto);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return _mappper.Map<ReadUserDto>(user);
    }

    public async Task<ReadUserDto?> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user == null ? null : _mappper.Map<ReadUserDto>(user);
    }

    public async Task<IEnumerable<ReadUserDto>> GetAllUsers()
    {
        var users = await _context.Users.AsNoTracking().ToListAsync();
        return users.Select(user => _mappper.Map<ReadUserDto>(user));
    }

    public async Task<ReadUserDto?> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        _mappper.Map(updateUserDto, user);
        await _context.SaveChangesAsync();
        return _mappper.Map<ReadUserDto>(user);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
