using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }

    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }

    class PlayHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "place the value number 1 in [0][0] square. \nFor example : Play 0 0 1")
            {
                return $"Type Play       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class SaveHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "save this game.")
            {
                return $"Type Save       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class LoadHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "load the game that has been saved.")
            {
                return $"Type Load       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class EndHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "switch your turn and pass it to your opponent.")
            {
                return $"Type End       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class ExitHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "exit the game.")
            {
                return $"Type Exit       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class UndoHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "cancel the previous action.")
            {
                return $"Type Undo       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class RedoHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "restore the action that was previously cancelled.")
            {
                return $"Type Redo       :Use this command when you want to {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class Command
    {
        
        public static void QuestionCode(AbstractHandler handler)
        {
            foreach (var command in new List<string> { "place the value number 1 in [0][0] square. \nFor example : Play 0 0 1", "save this game.", "load the game that has been saved.", "switch your turn and pass it to your opponent.", "exit the game.", "cancel the previous action.", "restore the action that was previously cancelled."})
            {
                Console.WriteLine($"How to {command}?\n");

                var result = handler.Handle(command);

                if (result != null)
                {
                    Console.Write($"   {result}\n");
                    
                }
                else
                {
                    Console.WriteLine($"   {command} \n");
                }
            }
        }
    }








}
