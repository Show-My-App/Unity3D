//
//  BTBHookBridge.h
//  BasicToolBoxOSX
//
//  Created by Jean-François CONTART on 07/06/2018.
//  Copyright © 2018 Jean-François CONTART. All rights reserved.
//


typedef void  (*UnityCommandCallback)(const char *sObjectname, const char *sCommandName , const char *sData);

extern "C" {
//    void ConnectCallback(UnityCommandCallback sCallBackMethod);
//    void CallbackMethod(const char *sObjectname, const char *sCommandName, const char *sData);
//    
//    
    void SingletonCallback(UnityCommandCallback sCallBackMethod);
    void SingletonSendMessage(const char *sObjectname, const char *sCommandName, const char *sData);
}
