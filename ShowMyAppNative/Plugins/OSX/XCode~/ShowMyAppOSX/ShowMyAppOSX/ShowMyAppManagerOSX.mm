#import "ShowMyAppManagerOSX.h"
#include "ShowMyAppHookBridge.h"

@implementation ShowMyAppManagerOSX

+(NSString *) charToNSString:(char *)sValue {
    if (sValue != NULL) {
        return [NSString stringWithUTF8String: sValue];
    } else {
        return [NSString stringWithUTF8String: ""];
    }
}

+(const char *)NSIntToChar:(NSInteger)sValue {
    NSString *tTmp = [NSString stringWithFormat:@"%ld", (long)sValue];
    return [tTmp UTF8String];
}

+ (const char *)NSStringToChar:(NSString *)sValue {
    return [sValue UTF8String];
}

+(void)showShare:(NSString*) sMessage gameObjectName:(NSString*)sGameObjectName callBackName:(NSString*)sCallBackName {
    NSAlert *tAlert = [[NSAlert alloc] init];
    [tAlert setMessageText:@"SHARE OK"];
    [tAlert setInformativeText:sMessage];
    [tAlert addButtonWithTitle:@"OK"];
    [tAlert setAlertStyle:NSAlertStyleWarning];
    if ([tAlert runModal] == NSAlertFirstButtonReturn) {
        SingletonSendMessage([ShowMyAppManagerOSX NSStringToChar:sGameObjectName], [ShowMyAppManagerOSX NSStringToChar:sCallBackName],  [ShowMyAppManagerOSX NSIntToChar:0]);
    }
}

extern "C" {
    void _ShowMyApp_ShowShare(char* sMessage, char* sGameObjectName, char* sCallBackName) {
        [ShowMyAppManagerOSX showShare:[ShowMyAppManagerOSX charToNSString:sMessage] gameObjectName:[ShowMyAppManagerOSX charToNSString:sGameObjectName] callBackName:[ShowMyAppManagerOSX charToNSString:sCallBackName]];
    }
}
@end
