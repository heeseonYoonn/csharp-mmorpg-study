namespace TextRPG.Course
{
    class ExceptionPractice
    {
        class TestException : Exception
        {
            internal TestException(string message) : base(message) { }
        }

        public void Run()
        {
            try
            {
                throw new TestException("TestException");
            }
            catch (NullReferenceException nre)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
            }
        }
    }
}
