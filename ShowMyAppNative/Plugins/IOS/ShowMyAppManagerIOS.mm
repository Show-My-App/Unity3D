#import "ShowMyAppManagerIOS.h"

@implementation ShowMyAppManagerIOS

+(NSString *) charToNSString:(char *)sValue {
    if (sValue != NULL) {
        return [NSString stringWithUTF8String:sValue];
    } else {
        return [NSString stringWithUTF8String:""];
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
    NSArray *tShared = [[NSArray alloc] initWithObjects:sMessage, nil];
    UIActivityViewController *tShareController = [[UIActivityViewController alloc] initWithActivityItems:tShared applicationActivities:NULL];
    [tShareController setCompletionWithItemsHandler:^(UIActivityType  _Nullable activityType, BOOL completed, NSArray * _Nullable returnedItems, NSError * _Nullable activityError) {
        if (completed == true)
        {
            UnitySendMessage([ShowMyAppManagerIOS NSStringToChar:sGameObjectName], [ShowMyAppManagerIOS NSStringToChar:sCallBackName],  [ShowMyAppManagerIOS NSIntToChar:0]);
        }
        else
        {
            UnitySendMessage([ShowMyAppManagerIOS NSStringToChar:sGameObjectName], [ShowMyAppManagerIOS NSStringToChar:sCallBackName],  [ShowMyAppManagerIOS NSIntToChar:1]);
        }
    }];
    if ( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad )
    {
        if ( [tShareController respondsToSelector:@selector(popoverPresentationController)] ) {
            // for ipad
            tShareController.popoverPresentationController.sourceView = [[[[UIApplication sharedApplication] keyWindow] rootViewController] view];
        }
    }
    [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:tShareController animated:YES completion:nil];
}

extern "C" {
    void _ShowMyApp_ShowShare(char* sMessage, char* sGameObjectName, char* sCallBackName) {
        [ShowMyAppManagerIOS showShare:[ShowMyAppManagerIOS charToNSString:sMessage] gameObjectName:[ShowMyAppManagerIOS charToNSString:sGameObjectName] callBackName:[ShowMyAppManagerIOS charToNSString:sCallBackName]];
    }
}
@end
