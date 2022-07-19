using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.DataAccess.Repository;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagement.DataAccess.Data
{
    public class AppDbInitializer
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SchoolManagementDbContext>();

                context.Database.EnsureCreated();

                List<Topic> topicList1 = new List<Topic>();

                topicList1.AddRange(new List<Topic>() { new Topic() { Name = "Math-1" },
                                new Topic() { Name="English-1"},new Topic() { Name="Computer Programming-1"},new Topic() { Name="German-1"}});

                List<Topic> topicList2 = new List<Topic>();

                topicList2.AddRange(new List<Topic>() { new Topic() { Name = "Math-2" },
                                new Topic() { Name="English-2"},new Topic() { Name="Computer Programming-2"},new Topic() { Name="German-2"}});

                List<Topic> topicList3 = new List<Topic>();
                topicList3.AddRange(new List<Topic>() { new Topic() { Name = "Math-3" },
                                new Topic() { Name="English-3"},new Topic() { Name="Computer Programming-3"},new Topic() { Name="German-3"}});
                List<Topic> topicList4 = new List<Topic>();
                topicList4.AddRange(new List<Topic>() { new Topic() { Name = "Math-4" },
                                new Topic() { Name="English-4"},new Topic() { Name="Computer Programming-4"},new Topic() { Name="German-4"}});
                List<Topic> topicList5 = new List<Topic>();
                topicList5.AddRange(new List<Topic>() { new Topic() { Name = "Math-5" },
                                new Topic() { Name="English-5"},new Topic() { Name="Computer Programming-5"},new Topic() { Name="German-5"}});
                List<Topic> topicList6 = new List<Topic>();

                topicList6.AddRange(new List<Topic>() { new Topic() { Name = "Math-6" },
                                new Topic() { Name="English-6"},new Topic() { Name="Computer Programming-6"},new Topic() { Name="German-6"}});



                Stage stage1 = new Stage()
                {
                    StageNumber = 1,
                    topicList=topicList1
                    

                };
                Stage stage2 = new Stage()
                {
                    StageNumber = 2,
                    topicList = topicList2
                };

                Stage stage3 = new Stage()
                {
                    StageNumber = 3,
                    topicList = topicList3
                };

                Stage stage4 = new Stage()
                {
                    StageNumber = 4,
                    topicList = topicList4

                };


                Stage stage5 = new Stage()
                {
                    StageNumber = 5,
                    topicList = topicList5

                };


                Stage stage6 = new Stage()
                {
                    StageNumber = 6,
                    topicList = topicList6

                };

                context.stages.Add(stage1);
                context.stages.Add(stage2);
                context.stages.Add(stage3);
                context.stages.Add(stage4);
                context.stages.Add(stage5);
                context.stages.Add(stage6);

                context.SaveChanges();



            }

        }
    }
}
//List<Topic> topicList1 = new List<Topic>();

//topicList1.AddRange(new List<Topic>() { new Topic() { Name = "Math-1" },
//                new Topic() { Name="English-1"},new Topic() { Name="Computer Programming-1"},new Topic() { Name="German-1"}});

//List<Topic> topicList2 = new List<Topic>();

//topicList2.AddRange(new List<Topic>() { new Topic() { Name = "Math-2" },
//                new Topic() { Name="English-2"},new Topic() { Name="Computer Programming-2"},new Topic() { Name="German-2"}});

//List<Topic> topicList3 = new List<Topic>();
//topicList3.AddRange(new List<Topic>() { new Topic() { Name = "Math-3" },
//                new Topic() { Name="English-3"},new Topic() { Name="Computer Programming-3"},new Topic() { Name="German-3"}});
//List<Topic> topicList4 = new List<Topic>();
//topicList4.AddRange(new List<Topic>() { new Topic() { Name = "Math-4" },
//                new Topic() { Name="English-4"},new Topic() { Name="Computer Programming-4"},new Topic() { Name="German-4"}});
//List<Topic> topicList5 = new List<Topic>();
//topicList5.AddRange(new List<Topic>() { new Topic() { Name = "Math-5" },
//                new Topic() { Name="English-5"},new Topic() { Name="Computer Programming-5"},new Topic() { Name="German-5"}});
//List<Topic> topicList6 = new List<Topic>();

//topicList6.AddRange(new List<Topic>() { new Topic() { Name = "Math-6" },
//                new Topic() { Name="English-6"},new Topic() { Name="Computer Programming-6"},new Topic() { Name="German-6"}});

//Stage stage1 = new Stage()
//{
//    StageNumber = 1

//};
//Stage stage2 = new Stage()
//{
//    StageNumber = 2

//};

//Stage stage3 = new Stage()
//{
//    StageNumber = 3

//};

//Stage stage4 = new Stage()
//{
//    StageNumber = 4

//};


//Stage stage5 = new Stage()
//{
//    StageNumber = 5

//};


//Stage stage6 = new Stage()
//{
//    StageNumber = 6

//};
//_unitOfWork.stage.Add(stage1);
////   _unitOfWork.stage.Add(stage3);
//// _unitOfWork.stage.Add(stage4);
////  _unitOfWork.stage.Add(stage5);
////_unitOfWork.stage.Add(stage6);