//? https://stackoverflow.com/a/62184271
var plugin = {
	WebSendLoadProgress: function(progress)
	{
		// console.log(`[ WebSendLoadProgress ] ${progress}`);
		SetLoadProgress(progress);
	},

	WebNotifyLoaded: function()
	{
		// console.log("[ WebNotifyLoaded ]");
		NotifyLoaded();
	},

	WebGetStartupDelay: function()
	{
		return StartupDelay;
	},
};

mergeInto(LibraryManager.library, plugin);