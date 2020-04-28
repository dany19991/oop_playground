using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StatePatterns_try2
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();
            document.publish();
            document.currentUser = "user";
            document.publish();
            document.publish();
            document.currentUser = "admin";
            document.publish();
            document.publish();
        }
    }

    public class Document //context
    {
        State currentState=null;
        public string currentUser= "none";
        public DraftState draftState;
        public ModerationState moderationState;
        public PublishedState publishedState;

        public Document()
        {
            draftState = new DraftState(this);
            moderationState = new ModerationState();
            publishedState = new PublishedState();
            this.changeState(draftState);
        }

        public void render()
        { 
        }
        public void publish()
        {
            Console.WriteLine("Current user is " + currentUser);
            currentState.publish(this);
        }
        
        public void changeState(State state)
        {
            currentState = state;
            currentState.onEnterState(this);
        }
    }

    public interface State 
    {
        void render(Document document);
        void publish(Document document);
        void onEnterState(Document document);
    }

    public class DraftState : State
    {
        Document documentLoc; 
        public DraftState(Document document_)
        {
            documentLoc = document_;
        }
        public void onEnterState(Document document)
        {
            Console.WriteLine("Entered draft State");
        }

        public void publish(Document document)
        {
            
            if (documentLoc.currentUser.Equals("user")) //utilizare mixta, doar sa se vada ca se poate
            {
                document.changeState(document.moderationState);
            }
            else if (documentLoc.currentUser.Equals("admin"))
            {
                document.changeState(document.publishedState);
            }
            else 
            {
                Console.WriteLine("user is not set correctly");
            }
        }

        public void render(Document document)
        {
        }
    }

    public class ModerationState : State
    {
        public void onEnterState(Document document)
        {
            Console.WriteLine("Entered moderation state");
        }

        public void publish(Document document)
        {
            if (document.currentUser == "admin")
            {
                document.changeState(document.publishedState);
            }else
            {
                Console.WriteLine("only the admin can approve a document in moderation state");
            }
        }

        public void render(Document document)
        {
        }
    }

    public class PublishedState : State
    {
        public void onEnterState(Document document)
        {
            Console.WriteLine("Entered published state");
        }

        public void publish(Document document)
        {
            Console.WriteLine("document already published, nothing more to do");
        }

        public void render(Document document)
        {

        }
    }

}
