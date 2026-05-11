namespace ClassScheduleTests
{
    public class TeacherControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var mock = new Mock<IRepository<Teacher>>();
            var controller = new TeacherController(mock.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void IndexActionMethod_ModelIsAListOfTeacherObjects()
        {
            // arrange
            var teachers = new List<Teacher>();
            var mock = new Mock<IRepository<Teacher>>();
            mock.Setup(m => m.List(It.IsAny<QueryOptions<Teacher>>()))
                .Returns(teachers);
            var controller = new TeacherController(mock.Object);

            // act
            var result = controller.Index();

            // assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<List<Teacher>>(viewResult.Model);
        }
    }
}
