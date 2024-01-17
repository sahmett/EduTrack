using NToastNotify;

namespace EduTrack.MVC.Services
{
    public class ToastService : IToastService
    {
        private readonly IToastNotification _toastNotification;

        public ToastService(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        public void FailureMessage(string message)
        {
            _toastNotification.AddErrorToastMessage(message);
        }

        public void SuccessMessage(string message)
        {
            _toastNotification.AddSuccessToastMessage(message);
        }
    }
}
