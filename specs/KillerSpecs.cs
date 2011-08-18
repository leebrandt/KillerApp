using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Data;
using Core.Data.NHibernate;
using Core.Domain;
using FakeItEasy;
using Machine.Specifications;
using MvcContrib.TestHelper;
using Web.UI.Controllers;

namespace Specifications
{
    public class When_a_user_wishes_to_view_a_list_of_killers : With_main_site_routes_registered
    {
        It should_navigate_to_the_killer_listing_page = () =>
            "~/killer".ShouldMapTo<Web.UI.Controllers.KillerController>(ctrl => ctrl.Index());
    }

    public class When_navigating_to_the_killer_listing_page
    {
        Establish context = () =>
            {
                _killerRepository = A.Fake<KillerRepository>();
                _controller = new KillerController(_killerRepository);
            };

        Because of = () => _result = _controller.Index();

        It should_get_all_the_killers = () =>
            A.CallTo(() => _killerRepository.GetAll()).MustHaveHappened();

        It should_load_the_killer_listing_page = () =>
            _result.AssertViewRendered().ForView("Index");

        It should_load_the_killers_into_the_listing_page = () =>
            _result.AssertViewRendered().Model.ShouldBe(typeof(IList<Killer>));

        static KillerController _controller;
        static KillerRepository _killerRepository;
        static ActionResult _result;
    }

    public class When_getting_all_the_killers
    {
        Establish context = () =>
            {
                _repository = A.Fake<Repository>();
                A.CallTo(() => _repository.All<Killer>()).Returns(new List<Killer>
                                                                      {
                                                                          new Killer(), 
                                                                          new Killer(), 
                                                                          new Killer()
                                                                      }.AsQueryable());
                _killerRepository = new NHibernateKillerRepository(_repository);
            };

        Because of = () => _result = _killerRepository.GetAll();

        It should_search_storage_for_killers = () =>
            A.CallTo(() => _repository.All<Killer>()).MustHaveHappened();

        It should_return_all_of_them = () => _result.Count.ShouldEqual(3);

        static Repository _repository;
        static NHibernateKillerRepository _killerRepository;
        static IList<Killer> _result;
    }
}