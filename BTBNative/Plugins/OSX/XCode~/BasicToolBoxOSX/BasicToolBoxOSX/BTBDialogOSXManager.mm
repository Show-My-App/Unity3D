//
//  BTBHookBridge.m
//  BasicToolBoxOSX
//
//  Created by Jean-François CONTART on 07/06/2018.
//  Copyright © 2018 Jean-François CONTART. All rights reserved.
//
#import "BTBDialogOSXManager.h"
#include "BTBHookBridge.h"
//void CallMethod(const char *objectname, const char *commandName, const char *commandata);

@implementation BTBDialogOSXManager

static NSAlert* kCurrentAlert =  nil;

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

//+(void) dismissCurrentAlert {
//    if(kCurrentAlert != nil) {
//        [kCurrentAlert dismissViewControllerAnimated:NO completion:nil];
//        kCurrentAlert = nil;
//    }
//}

+ (void) showDialog: (NSString *) title message: (NSString*) msg yesTitle:(NSString*) b1 noTitle: (NSString*) b2{
    NSAlert *tAlert = [[NSAlert alloc] init];
    [tAlert setMessageText:title];
    [tAlert setInformativeText:msg];
    [tAlert addButtonWithTitle:b1];
    [tAlert addButtonWithTitle:b2];
    [tAlert setAlertStyle:NSAlertStyleWarning];
    NSModalResponse tResult = [tAlert runModal];
    if (tResult == NSAlertFirstButtonReturn) {
//        NSLog(@"click on propositin one");
//        CallbackMethod("BTBDialogOSX_GameObject", "OnDialogCallback",  [BTBDialogOSXManager NSIntToChar:0]);
        SingletonSendMessage("BTBDialogOSX_GameObject", "OnDialogCallback",  [BTBDialogOSXManager NSIntToChar:0]);
    }
    else
    {
//    NSLog(@" click on propositin two");
//       CallbackMethod("BTBDialogOSX_GameObject", "OnDialogCallback",  [BTBDialogOSXManager NSIntToChar:1]);
    SingletonSendMessage("BTBDialogOSX_GameObject", "OnDialogCallback",  [BTBDialogOSXManager NSIntToChar:1]);
    }
}
+(void)showAlert: (NSString *) title message: (NSString*) msg okTitle:(NSString*) b1 {
     NSAlert *tAlert = [[NSAlert alloc] init];
    [tAlert setMessageText:title];
    [tAlert setInformativeText:msg];
    [tAlert addButtonWithTitle:b1];
    [tAlert setAlertStyle:NSAlertStyleWarning];
    if ([tAlert runModal] == NSAlertFirstButtonReturn) {
//        NSLog(@" click on propositin alert");
//       CallbackMethod("BTBAlertOSX_GameObject", "OnAlertCallback",  [BTBDialogOSXManager NSIntToChar:0]);
        SingletonSendMessage("BTBAlertOSX_GameObject", "OnAlertCallback",  [BTBDialogOSXManager NSIntToChar:0]);
    }
}

+(void)showShare: (NSString *) title message: (NSString*) msg okTitle:(NSString*) b1 {
    NSAlert *tAlert = [[NSAlert alloc] init];
    [tAlert setMessageText:@"SHARE OK"];
    [tAlert setInformativeText:msg];
    [tAlert addButtonWithTitle:b1];
    [tAlert setAlertStyle:NSAlertStyleWarning];
    if ([tAlert runModal] == NSAlertFirstButtonReturn) {
        //        NSLog(@" click on propositin alert");
        //       CallbackMethod("BTBAlertOSX_GameObject", "OnAlertCallback",  [BTBDialogOSXManager NSIntToChar:0]);
        SingletonSendMessage("BTBAlertOSX_GameObject", "OnAlertCallback",  [BTBDialogOSXManager NSIntToChar:0]);
    }
}

extern "C" {
    void _BTB_ShowDialog(char* title, char* message, char* yes, char* no) {
        [BTBDialogOSXManager showDialog:[BTBDialogOSXManager charToNSString:title] message:[BTBDialogOSXManager charToNSString:message] yesTitle:[BTBDialogOSXManager charToNSString:yes] noTitle:[BTBDialogOSXManager charToNSString:no]];
    }
    void _BTB_ShowAlert(char* title, char* message, char* ok) {
        [BTBDialogOSXManager showAlert:[BTBDialogOSXManager charToNSString:title] message:[BTBDialogOSXManager charToNSString:message] okTitle:[BTBDialogOSXManager charToNSString:ok]];
    }
    void _BTB_ShowShare(char* title, char* message, char* ok) {
        [BTBDialogOSXManager showShare:[BTBDialogOSXManager charToNSString:title] message:[BTBDialogOSXManager charToNSString:message] okTitle:[BTBDialogOSXManager charToNSString:ok]];
    }
//    void _BTB_DismissAlert() {
//        [BTBDialogOSXManager dismissCurrentAlert];
//    }
}
@end
