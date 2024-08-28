namespace AppiumExercises.Config
{
    public class Configure
    {
        public static readonly String WORK_DIRECTORY = Environment.CurrentDirectory;
        public static readonly String PROJ_DIRECTORY = Directory.GetParent(WORK_DIRECTORY).Parent.Parent.FullName;

        //public static readonly String ANDROID_DEVICE_NAME = "R3CR40TYP5Y";
        public static readonly String MYQ_USERNAME = AppSettings.get("MyQ_App:User");
        public static readonly String MYQ_PASSWORD = AppSettings.get("MyQ_App:Password");
        public static readonly String WIFI_NAME_PROVISIONING = "MyQ-102";
        public const int SELENIUM_WAIT_TIMEOUT = 20; //[s]
    }
}
