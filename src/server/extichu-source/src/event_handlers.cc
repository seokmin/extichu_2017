// PLEASE ADD YOUR EVENT HANDLER DECLARATIONS HERE.

#include "event_handlers.h"

#include <funapi.h>
#include <gflags/gflags.h>
#include <glog/logging.h>

#include "extichu_loggers.h"
#include "extichu_messages.pb.h"


// You can differentiate game server flavors.
DECLARE_string(app_flavor);


namespace extichu {

////////////////////////////////////////////////////////////////////////////////
// Session open/close handlers
////////////////////////////////////////////////////////////////////////////////

void OnSessionOpened(const Ptr<Session> &session) {
  logger::SessionOpened(to_string(session->id()), WallClock::Now());
}


void OnSessionClosed(const Ptr<Session> &session, SessionCloseReason reason) {
  logger::SessionClosed(to_string(session->id()), WallClock::Now());

  if (reason == kClosedForServerDid) {
    // Server has called session->Close().
  } else if (reason == kClosedForIdle) {
    // The session has been idle for long time.
  } else if (reason == kClosedForUnknownSessionId) {
    // The session was invalid.
  }
}



////////////////////////////////////////////////////////////////////////////////
// Client message handlers.
//
// (Just for your reference. Please replace with your own.)
////////////////////////////////////////////////////////////////////////////////


////////////////////////////////////////////////////////////////////////////////
// Timer handler.
//
// (Just for your reference. Please replace with your own.)
////////////////////////////////////////////////////////////////////////////////

void OnTick(const Timer::Id &timer_id, const WallClock::Value &clock) {
  // PLACE HERE YOUR TICK HANDLER CODE.
}




////////////////////////////////////////////////////////////////////////////////
// Extend the function below with your handlers.
////////////////////////////////////////////////////////////////////////////////

void RegisterEventHandlers() {
  /*
   * Registers handlers for session close/open events.
   */
  {
    HandlerRegistry::Install2(OnSessionOpened, OnSessionClosed);
  }


  /*
   * Registers handlers for messages from the client.
   *
   * Handlers below are just for you reference.
   * Feel free to delete them and replace with your own.
   */
  {
  }


  /*
   * Registers a timer.
   *
   * Below demonstrates a repeating timer. One-shot timer is also available.
   * Please see the Timer class.
   */
  {
    Timer::ExpireRepeatedly(boost::posix_time::seconds(1), extichu::OnTick);
  }
}

}  // namespace extichu
