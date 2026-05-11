namespace ClassScheduleTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var classMock = new Mock<IRepository<Class>>();
            var dayMock = new Mock<IRepository<Day>>();
            var controller = new HomeController(classMock.Object, dayMock.Object);

            // act
            var result = controller.Index(0);

            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
