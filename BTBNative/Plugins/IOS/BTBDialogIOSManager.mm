#import "BTBDialogIOSManager.h"

@implementation BTBDialogIOSManager

static UIAlertController* kCurrentAlert =  nil;
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
+ (void) unregisterAllertView {
    if(kCurrentAlert != nil) {
        kCurrentAlert = nil;
    }
}
+(void) dismissCurrentAlert {
    if(kCurrentAlert != nil) {
        [kCurrentAlert dismissViewControllerAnimated:NO completion:nil];
        kCurrentAlert = nil;
    }
}
+ (void) showDialog: (NSString *) title message: (NSString*) msg yesTitle:(NSString*) b1 noTitle: (NSString*) b2{
    UIAlertController *alertController = [UIAlertController alertControllerWithTitle:title message:msg preferredStyle:UIAlertControllerStyleAlert];
    UIAlertAction *yesAction = [UIAlertAction actionWithTitle:b1 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        UnitySendMessage("BTBDialogIOS_GameObject", "OnDialogCallback",  [BTBDialogIOSManager NSIntToChar:0]);
        [BTBDialogIOSManager unregisterAllertView];
    }];
    UIAlertAction *noAction = [UIAlertAction actionWithTitle:b2 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        UnitySendMessage("BTBDialogIOS_GameObject", "OnDialogCallback",  [BTBDialogIOSManager NSIntToChar:1]);
        [BTBDialogIOSManager unregisterAllertView];
    }];
    [alertController addAction:yesAction];
    [alertController addAction:noAction];
    [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
    kCurrentAlert = alertController;
}
+(void)showAlert: (NSString *) title message: (NSString*) msg okTitle:(NSString*) b1 {
    UIAlertController *alertController = [UIAlertController alertControllerWithTitle:title message:msg preferredStyle:UIAlertControllerStyleAlert];
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:b1 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        UnitySendMessage("BTBAlertIOS_GameObject", "OnAlertCallback",  [BTBDialogIOSManager NSIntToChar:0]);
        [BTBDialogIOSManager unregisterAllertView];
    }];
    [alertController addAction:okAction];
    [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
    kCurrentAlert = alertController;
}

extern "C" {
    void _BTB_ShowDialog(char* title, char* message, char* yes, char* no) {
        [BTBDialogIOSManager showDialog:[BTBDialogIOSManager charToNSString:title] message:[BTBDialogIOSManager charToNSString:message] yesTitle:[BTBDialogIOSManager charToNSString:yes] noTitle:[BTBDialogIOSManager charToNSString:no]];
    }
    void _BTB_ShowAlert(char* title, char* message, char* ok) {
        [BTBDialogIOSManager showAlert:[BTBDialogIOSManager charToNSString:title] message:[BTBDialogIOSManager charToNSString:message] okTitle:[BTBDialogIOSManager charToNSString:ok]];
    }
    void _BTB_DismissAlert() {
        [BTBDialogIOSManager dismissCurrentAlert];
    }
}
@end
