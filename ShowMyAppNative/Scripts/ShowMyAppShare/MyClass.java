package com.idemobi.show_my_app;

import com.unity3d.player.UnityPlayerActivity;
import com.unity3d.player.UnityPlayer;

import android.app.Activity;
import android.util.Log;
import android.widget.Toast;

import java.util.Locale;

public class MyClass {
    private Activity mCurrentActivity;

    public void setActivity(Activity activity) {
        mCurrentActivity = activity;
    }
    
    public void testMethod2(String data) {
        Log.d("TAG", "The data was " + data);
    }
    
    public static void testMethod(String data) {
        Log.d("TAG", "The data was " + data);
    }
    
    pubic void ShowShare(String sUrl) {
        Intent sendIntent = new Intent(Intent.ACTION_VIEW);
        sendIntent.setData(Uri.parse(sUrl));
        startActivity(sendIntent);
    }
 
    /**
     * Displays a Toast message overlaid on screen with Target info
     */
    public void showTargetInfo(String targetName, float targetWidth, float targetHeight) {
        Log.d("MyPlugin", "Executing showTargetInfo native Android code");

        if (mCurrentActivity == null) {
            Log.e("MyPlugin", "Android Activity not set in plugin");
            return;
        }

        final String msg = String.format(Locale.ENGLISH,
                "Image Target %s - size: %5.2f x %5.2f",
                targetName, targetWidth, targetHeight);

        Log.d("MyPlugin", "Target Info: " + msg);

        mCurrentActivity.runOnUiThread(new Runnable() {
            public void run() {
                Toast.makeText(mCurrentActivity, msg, Toast.LENGTH_LONG).show();
            }
        });
    }
}