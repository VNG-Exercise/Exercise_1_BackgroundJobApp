using Exercise_1_BackgroundJobApp;

using var context = new ApplicationDbContext();
var job = new BackgroundJob();
var users = await BackgroundJob.FetchUsersForPasswordUpdateAsync(context);
await BackgroundJob.SendEmailNotificationsAsync(users);
