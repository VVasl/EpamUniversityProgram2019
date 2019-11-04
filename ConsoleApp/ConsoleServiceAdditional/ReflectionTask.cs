namespace ConsoleApp
{
    using Reflection;
    using Common;

    public class ReflectionTask : Tasks
    {
        private IShowMemberInfo memberWriter;

        public ReflectionTask()
        {
            this.memberWriter = new ConsoleInputOutput();
        }
        public void WriteInfoTask()
        {
            this.writer.Write("\tReflection Task : Write into console all assembly information");
            AllDllInformation info = new AllDllInformation(this.configuration["assemblyName"]);
            info.GetAllInfo(this.memberWriter);
        }
    }   
}
