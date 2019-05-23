#import "BTBUnitySingletonManager.h"
#include "BTBHookBridge.h"
@implementation BTBUnitySingletonManager

+ (id)sharedInstance {
    static BTBUnitySingletonManager * kSharedInstance;
    @synchronized(self) {
        if (kSharedInstance == nil)
            {
            kSharedInstance = [[self alloc] init];
            }
    }
    return kSharedInstance;
}

- (id)init {
    if (self = [super init]) {
        [self setReady:NO];
    }
    return self;
}

- (void)dealloc {
}

-(void)applicationDidFinishLaunching:(NSNotification *)notification
{
    NSLog(@"#### applicationDidLaunched notification");
}


-(void)handleAppleEvent:(NSAppleEventDescriptor *)event withReplyEvent:(NSAppleEventDescriptor *)replyEvent {
    NSString *urlString = [[event paramDescriptorForKeyword:keyDirectObject] stringValue];
    
    NSLog(@"RECEIPT INTERNAL URL %@", urlString);
    
    NSAlert *tAlert = [[NSAlert alloc] init];
    [tAlert setMessageText:@"URL SCHEME RECEIPT"];
    [tAlert setInformativeText:urlString];
    [tAlert addButtonWithTitle:@"OK"];
    [tAlert setAlertStyle:NSAlertStyleWarning];
    NSModalResponse tResult = [tAlert runModal];
    
    if ([[BTBUnitySingletonManager sharedInstance] Ready]==YES)
        {
//        NSLog(@"SEND URL TO SINGLETON");
        SingletonSendMessage("BTBUnitySingleton", "OnURLScheme",  [urlString UTF8String]);
        }
    else
        {
//        NSLog(@"MEMORIZE URL AND WAITING");
        [[BTBUnitySingletonManager sharedInstance] setURLQueue:urlString];
            // Will be sent when sharedInstance will be ready
        }
}

extern "C" {
    void _BTB_SingletonReady() {
//        NSAlert *tAlert = [[NSAlert alloc] init];
//        [tAlert setMessageText:@"BTBUnitySingletonManager"];
//        [tAlert setInformativeText:@"I am ready"];
//        [tAlert addButtonWithTitle:@"OK"];
//        [tAlert setAlertStyle:NSAlertStyleWarning];
//        NSModalResponse tResult = [tAlert runModal];
        [[BTBUnitySingletonManager sharedInstance] setReady:YES];
//        NSLog(@"_BTB_SingletonReady is ready");
            // If URLScheme is in waiting ... send it
        if ([[BTBUnitySingletonManager sharedInstance] URLQueue]!=nil)
            {
                // YES URLScheme was waiting to do
//            CallbackMethod("BTBUnitySingleton", "OnURLScheme", [[[BTBUnitySingletonManager sharedInstance] URLQueue] UTF8String]);
            SingletonSendMessage("BTBUnitySingleton", "OnURLScheme", [[[BTBUnitySingletonManager sharedInstance] URLQueue] UTF8String]);
            [[BTBUnitySingletonManager sharedInstance] setURLQueue:nil];
            }
    }
}
@end
