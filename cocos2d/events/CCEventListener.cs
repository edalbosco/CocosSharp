﻿using System;
using System.Collections.Generic;

namespace CocosSharp
{

    public enum CCEventListenerType
    {
        UNKNOWN,
        TOUCH_ONE_BY_ONE,
        TOUCH_ALL_AT_ONCE,
        KEYBOARD,
        MOUSE,
        ACCELERATION,
        CUSTOM
    }


    /// <summary>
    /// The base class of event listener.
    /// If you need custom listener with a different callback, you need to inherit this class.
    /// For instance, you could refer to EventListenerAcceleration, EventListenerKeyboard, EventListenerTouchOneByOne, EventListenerCustom.
    /// </summary>
    public class CCEventListener : IDisposable
    {

        protected virtual string ListenerID { get; set; }

        /// <summary>
        /// Whether the listener is paused
        /// </summary>
        internal virtual bool IsPaused { get; set; }

        /// <summary>
        /// Whether the listener has been added to dispatcher.
        /// </summary>
        protected virtual bool IsRegistered { get; set; }

        /// <summary>
        /// Event listener type
        /// </summary>
        protected virtual CCEventListenerType Type { get; set; }

        /// <summary>
        /// The priority of event listener
        /// The higher the number, the higher the priority, 0 is for scene graph base priority.
        /// </summary>
        internal virtual int FixePriority { get; set; }

        /// <summary>
        /// Scene graph based priority
        /// </summary>
        protected virtual CCNode SceneGraphPriorty { get; set; }

        /// <summary>
        /// Event callback function
        /// </summary>
        protected Action<CCEvent> OnEvent { get; set; }

        protected CCEventListener() 
        {
            IsRegistered = false;
            IsPaused = true;
        }

        protected CCEventListener(CCEventListenerType type, string listenerID)
            : this()
        {
            Type = type;
            ListenerID = listenerID;
        }

        /// <summary>
        /// Initializes event with type and callback function
        /// </summary>
        /// <param name="type"></param>
        /// <param name="listenerID"></param>
        /// <param name="callback"></param>
        protected CCEventListener(CCEventListenerType type, string listenerID, Action<CCEvent> callback)
            : this(type, listenerID)
        {
            OnEvent = callback;
        }


        /// <summary>
        /// Checks whether the listener is available. 
        /// </summary>
        public virtual bool IsAvailable
        {
            get { return OnEvent != null; }
        }

        // Clones the listener, its subclasses have to override this method.
        public virtual CCEventListener Copy()
        {
            // TODO: fix me
            return new CCEventListener();
        }

        #region IDisposable Methods

        public void Dispose()
        {
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources
                // Release our Managed Resources
            }
            else
            {
                // Do nothing, no one asked a dispose, the object went out of
                // scope and finalized is called so lets next round of GC 
                // release these resources
            }

            // Release the unmanaged resource in any case as they will not be 
            // released by GC

        }

        #endregion

        ~CCEventListener()
        {
            // The object went out of scope and finalized is called
            // Lets call dispose in to release unmanaged resources 
            // the managed resources will anyways be released when GC 
            // runs the next time.
            Dispose(false);
            Console.WriteLine("In the finalizer of CCEventListener. {0}", this);
        }

    }

    public class CCNode
    {

    }

    //NS_CC_BEGIN

    //EventListener::EventListener()
    //{}

    //EventListener::~EventListener() 
    //{
    //    CCLOGINFO("In the destructor of EventListener. %p", this);
    //}

    //bool EventListener::init(Type t, const ListenerID& listenerID, const std::function<void(Event*)>& callback)
    //{
    //    _onEvent = callback;
    //    _type = t;
    //    _listenerID = listenerID;
    //    _isRegistered = false;
    //    _paused = true;

    //    return true;
    //}

    //bool EventListener::checkAvailable()
    //{ 
    //    return (_onEvent != nullptr);
    //}

}