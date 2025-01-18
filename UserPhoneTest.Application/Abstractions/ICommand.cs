using MediatR;

namespace UserPhoneTest.Application.Abstractions;

public interface ICommand<TResponse> : IRequest<TResponse>;

public interface ICommand : IRequest;
