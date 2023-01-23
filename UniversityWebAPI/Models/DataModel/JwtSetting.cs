namespace UniversityWebAPI.Models.DataModel
{
    public class JwtSetting
    {
        public bool ValidateIssuerSigningKey { get; set; } = true;
        public string IssuerSigningKey { get; set;} = string.Empty;


        public bool ValidateIssuer { get; set; } = true;
        public string ValidIssuer { get; set; }


        public bool ValidateAudience { get; set; } = true;
        public string ValidAudience { get; set; }


        public bool RequireExpirationTime { get; set; } = true;
        public string ValidateLifeTime { get; set; }


    }
}
