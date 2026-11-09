using Flunt.Notifications;
using Flunt.Validations;

namespace MiniTodo.ViewModels;

public class CreateTodoViewModel : Notifiable<Notification>
{
    public string Title { get; set; }

    public Todo MapTo()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(Title, nameof(Title), "O título é obrigatório")
            .IsGreaterThan(Title, 5, nameof(Title), "O título deve ter mais de 3 caracteres");

        AddNotifications(contract);
        return new Todo(Guid.NewGuid(), Title, false);
    }
}