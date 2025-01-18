using MediatR;

namespace UserPhoneTest.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>;