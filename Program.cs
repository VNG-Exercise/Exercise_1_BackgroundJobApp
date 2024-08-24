using Exercise_1_BackgroundJobApp;

using var context = new ApplicationDbContext();

var timer = new Timer(ExecuteJobAsync, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

Console.WriteLine("Press [Enter] to exit the program...");
Console.ReadLine();

async void ExecuteJobAsync(object? state)
{
    Console.WriteLine("Job Starting.....");

    var job = new BackgroundJob();
    var users = await BackgroundJob.FetchUsersForPasswordUpdateAsync(context);
    await BackgroundJob.SendEmailNotificationsAsync(users);

    Console.WriteLine("Job Completed!!!");
}
