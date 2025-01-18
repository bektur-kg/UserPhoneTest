﻿using UserPhoneTest.Domain.Abstractions;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Domain.Modules.Phones;

public class Phone : Entity
{   
    public required string PhoneNumber { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}