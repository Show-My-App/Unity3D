#import "BTBUnitySingletonManager.h"
@implementation BTBUnitySingletonManager
/// memory in static

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
        Ready = NO;
    }
    return self;
}

- (void)dealloc {
}

extern "C" {
    void _BTB_SingletonReady() {
//        UIAlertView *tAlert =[[UIAlertView alloc] initWithTitle:@"BTBUnitySingleton" message:@"Singleton is ready" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil];
//        [tAlert show];
        [[BTBUnitySingletonManager sharedInstance] setReady:YES];
        if ([[BTBUnitySingletonManager sharedInstance] URLQueue]!=nil)
            {
            UnitySendMessage("BTBUnitySingleton", "OnURLScheme", [[[BTBUnitySingletonManager sharedInstance] URLQueue] UTF8String]);
            [[BTBUnitySingletonManager sharedInstance] setURLQueue:nil];
            }
    }
}
@end
