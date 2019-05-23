//
//  BTBHookBridge.m
//  BasicToolBoxOSX
//
//  Created by Jean-François CONTART on 07/06/2018.
//  Copyright © 2018 Jean-François CONTART. All rights reserved.
//

#import <Cocoa/Cocoa.h>

#include "BTBHookBridge.h"
//#import "BTBDialogOSXManager.h"

//static UnityCommandCallback kLastCallback = NULL;
//
//void ConnectCallback (UnityCommandCallback sCallbackMethod){
////    NSLog(@"ConnectCallback called");
//    kLastCallback = sCallbackMethod;
//}
//
//void CallbackMethod (const char * sObjectName, const char * sCommandName, const char * sData){
//    if (kLastCallback != NULL)
//        {
//        kLastCallback(sObjectName, sCommandName, sData);
//        }
//    else
//        {
////        NSLog(@"lastCallback is null");
//        }
//}

static UnityCommandCallback kSingletonCallback = NULL;

void SingletonCallback (UnityCommandCallback sCallbackMethod){
        //    NSLog(@"ConnectCallback called");
    kSingletonCallback = sCallbackMethod;
}

void SingletonSendMessage (const char * sObjectName, const char * sCommandName, const char * sData){
    if (kSingletonCallback != NULL)
        {
        kSingletonCallback(sObjectName, sCommandName, sData);
        }
    else
        {
            //        NSLog(@"SingletonCallback is null");
        }
}
