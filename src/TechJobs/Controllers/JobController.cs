using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            //  #1 - get the Job with the given ID and pass it into the view DONE

            return View(jobData.Jobs[id]);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            //  #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (newJobViewModel != null)
            {
                Models.Employer employer = jobData.Employers.Find(newJobViewModel.EmployerID);
                Models.Location location = jobData.Locations.Find(newJobViewModel.LocationID);
                Models.PositionType positionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);
                Models.CoreCompetency coreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID);

                Models.Job newJob = new Models.Job
                {
                    Name = newJobViewModel.Name,
                    Employer = employer,
                    Location = location,
                    PositionType = positionType,
                    CoreCompetency = coreCompetency
                };
                jobData.Jobs.Add(newJob);

                return View("Index", newJob);
            }

            return View(newJobViewModel);
        }
    }
}
