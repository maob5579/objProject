using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MoodWcfService.Entities;
using MoodWcfService.Model;

namespace MoodWcfService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EvaluationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EvaluationService.svc or EvaluationService.svc.cs at the Solution Explorer and start debugging.
    public class EvaluationService : IEvaluationService
    {
        public List<Evaluation_> GetAllEvaluations()
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                return moodFullDb.Evaluations.Select(x => new Evaluation_
                {
                    EvaluationId = x.EvaluationId,
                    UserId = x.UserId,
                    RestaurantId = x.RestaurantId,
                    MoodRating = x.MoodRating.Value,
                    Price = x.Price.Value,
                    Experience = x.Experience.Value
                }).ToList();
            };
        }
        public Evaluation_ GetEvaluationById(string evalId)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                int evaluationID = Convert.ToInt32(evalId);
                return moodFullDb.Evaluations.Where(x => x.EvaluationId == evaluationID).Select(x => new Evaluation_
                {
                    EvaluationId = x.EvaluationId,
                    UserId = x.UserId,
                    RestaurantId = x.RestaurantId,
                    MoodRating = x.MoodRating.Value,
                    Price = x.Price.Value,
                    Experience = x.Experience.Value
                }).FirstOrDefault();
            }
        }

        public bool CreateEvaluation(Evaluation_ evaluation)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                try
                {
                    Evaluation xe = new Evaluation();
                    xe.UserId = evaluation.UserId;
                    xe.RestaurantId = evaluation.RestaurantId;
                    xe.MoodRating = evaluation.MoodRating;
                    xe.Price = evaluation.Price;
                    xe.Experience = evaluation.Experience;
                    moodFullDb.Evaluations.Add(xe);
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool EditEvaluation(Evaluation_ evaluation)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                try
                {
                    int evaluationId = Convert.ToInt32(evaluation.EvaluationId);
                    Evaluation xe = moodFullDb.Evaluations.Single(x => x.EvaluationId == evaluationId);
                    xe.UserId = evaluation.UserId;
                    xe.RestaurantId = evaluation.RestaurantId;
                    xe.MoodRating = evaluation.MoodRating;
                    xe.Price = evaluation.Price;
                    xe.Experience = evaluation.Experience;
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
        }
        public bool DeleteEvaluation(Evaluation_ evaluation)
        {
            using (MoodFullEntities moodFullDb = new MoodFullEntities())
            {
                try
                {
                    int evaluationID = Convert.ToInt32(evaluation.EvaluationId);
                    Evaluation xe = moodFullDb.Evaluations.Single(x => x.EvaluationId == evaluationID);
                    moodFullDb.Evaluations.Remove(xe);
                    moodFullDb.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
