using Microsoft.AspNetCore.Mvc;

namespace QuestionnaireLineBot.Filter
{
    public class LineVerifySignatureAttribute : TypeFilterAttribute
    {
        public LineVerifySignatureAttribute() : base(typeof(LineVerifySignatureFilter))
        {
        }
    }
}
