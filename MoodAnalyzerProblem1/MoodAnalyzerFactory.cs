using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem1
{
    public class ModeAnalyzerReflector
    {
       
        public object CreateMoodAnalyzerObject(string className, string constructor)
        {
            string pattern = "." + constructor + "$";
            Match result = System.Text.RegularExpressions.Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    //creating type means class, by taking class name
                    Type moodAnalyzerType = assembly.GetType(className);
                    
                    var res = Activator.CreateInstance(moodAnalyzerType);
                    return res;
                }
                catch (Exception)
                {
                    throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }

        //Uc5 to create parametrized constructor
        public object CreateMoodAnalyzerParameterizedObject(string className, string constructor, string message)
        {
            try
            {
                //tyoeof() used to get the type
                Type type = typeof(MoodAnalyzer);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructor))
                    {
                        //typeof(string) for decide which constrtor we need perticularly
                        ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                        //Invoke() used to pass the message to that parameterized constructor
                        //Invoke() will return a object
                        var obj = constructorInfo.Invoke(new object[] { message });
                        return obj;
                    }
                    else
                    {
                        throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                    }
                }
                else
                {
                    throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            catch (CustomMoodAnalyzerException ex)
            {
                throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_CONSTRUCTOR, ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Uc-6 invoke MoodAnalyze() using reflection
        public string InvokeAnalyzer(string message, string methodName)
        {
            try
            {
                //Type takes the class name
                Type type = typeof(MoodAnalyzer);
                //Listing all methods present in this class
                MethodInfo methodInfo = type.GetMethod(methodName);
                //creating object
                ModeAnalyzerReflector factory = new ModeAnalyzerReflector();
                //creating object ,calling parameterized reflection meythod to pass details
                object moodAnalyserObject = factory.CreateMoodAnalyzerParameterizedObject("Mood_Analyzer_Problem.MoodAnalyzer", "MoodAnalyzer", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "happy");
            }
        }

        //UC7 change mood dynamically 
        //field-variable
        public string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyzer moodAnalyser = new MoodAnalyzer();
                //Type takes the class name
                Type type = typeof(MoodAnalyzer);
              
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                //SetValue-it sets the value of the field(object)
                fieldInfo.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new CustomMoodAnalyzerException(CustomMoodAnalyzerException.ExceptionType.NO_SUCH_FIELD, "Field is not found");
            }
        }
    }
}