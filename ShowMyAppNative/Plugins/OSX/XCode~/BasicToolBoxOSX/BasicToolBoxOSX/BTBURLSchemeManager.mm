//
//  BTBOverrideAppDelegate.m
//  BasicToolBoxOSX
//
//  Created by Jean-François CONTART on 13/06/2018.
//  Copyright © 2018 Jean-François CONTART. All rights reserved.
//
#import "BTBURLSchemeManager.h"
#import "BTBUnitySingletonManager.h"
#include "BTBHookBridge.h"
#import <Cocoa/Cocoa.h>

@implementation BTBURLSchemeManager

+(void)load
{
    NSLog(@"BTBURLSchemeManager load");
    [super load];
    [[NSAppleEventManager sharedAppleEventManager] setEventHandler:[BTBUnitySingletonManager sharedInstance] andSelector:@selector(handleAppleEvent:withReplyEvent:) forEventClass:kInternetEventClass andEventID:kAEGetURL];
    
    [[NSNotificationCenter defaultCenter] addObserver:[BTBUnitySingletonManager sharedInstance] selector:@selector(applicationDidFinishLaunching:) name:NSApplicationDidFinishLaunchingNotification object:nil];
}
@end
