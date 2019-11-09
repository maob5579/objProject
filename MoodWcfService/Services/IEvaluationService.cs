using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoodWcfService.Entities;

namespace MoodWcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEvaluationService" in both code and config file together.
    [ServiceContract]
    public interface IEvaluationService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllEvaluations")]
        List<Evaluation_> GetAllEvaluations();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetEvaluationById/{evalId}")]
        Evaluation_ GetEvaluationById(string evalId);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Create")]
        bool CreateEvaluation(Evaluation_ evaluation);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Edit")]
        bool EditEvaluation(Evaluation_ evaluation);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Delete")]
        bool DeleteEvaluation(Evaluation_ evaluation);
    }
}
