﻿using gRPCExceptionHandling.Domain.Users.Exceptions;

namespace gRPCExceptionHandling.Domain.Users;

public class User
{
    public User(Guid id, string nationalCode, string? firstName, string? lastName, DateOnly birthdate)
    {
        Id = id;
        SetNationalCode(nationalCode);

        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
    }

    public Guid Id { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string NationalCode { get; private set; } = null!;
    public DateOnly Birthdate { get; private set; }

    private void SetNationalCode(string nationalCode)
    {
        if (nationalCode.Length != 10)
        {
            throw new NationalCodeIsInvalidException();
        }

        NationalCode = nationalCode;
    }
}