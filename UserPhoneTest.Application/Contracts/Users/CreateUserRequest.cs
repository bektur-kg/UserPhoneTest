﻿using System.ComponentModel.DataAnnotations;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Application.Contracts.Users;

public record CreateUserRequest
{
    [MaxLength(UserAttributeConstants.MaxNameLength)]
    public required string Name { get; init; }

    [EmailAddress]
    public required string Email { get; init; }

    public DateOnly DateOfBirth { get; init; }
}
