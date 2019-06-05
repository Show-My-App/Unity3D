package com.idemobi.show_my_app;

import android.app.Activity;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;

import java.util.Locale;

public class MyClass {

    private Activity mCurrentActivity;
    private static String TAG = "Plugin.MyClass";

    public void setActivity(Activity activity) {
        mCurrentActivity = activity;
    }

    public void ShowShare(final String sUrl) {
        Log.d(TAG, "Executing ShowShare native Android code");

        if (mCurrentActivity == null) {
            Log.e(TAG, "Android Activity not set in plugin");
            return;
        }

        Intent sendIntent = new Intent();
        sendIntent.setAction(Intent.ACTION_SEND);
        sendIntent.putExtra(Intent.EXTRA_TEXT, sUrl);
        sendIntent.setType("text/plain");
        Intent chooser = Intent.createChooser(sendIntent, "Share your new QRCode");
        mCurrentActivity.startActivity(chooser);
    }

    public void ShowTargetInfo(String targetName, float targetWidth, float targetHeight) {
        Log.d(TAG, "Executing showTargetInfo native Android code");

        if (mCurrentActivity == null) {
            Log.e(TAG, "Android Activity not set in plugin");
            return;
        }

        final String msg = String.format(Locale.ENGLISH,
                "Image Target %s - size: %5.2f x %5.2f",
                targetName, targetWidth, targetHeight);

        Log.d(TAG, "Target Info: " + msg);

        mCurrentActivity.runOnUiThread(new Runnable() {
            public void run() {
                Toast.makeText(mCurrentActivity, msg, Toast.LENGTH_LONG).show();
            }
        });
    }
}