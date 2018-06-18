



													TegraAutoSmash

			This program triggers a configured application to run when a switch is plugged in in RCM mode. The
		Default configuration is to run TegraRcmSmash and launch hekate, both stored in the resources/ folder.
		This behavior can be modified, however due to my own laziness there are some limitations:

			- Only one line will be read from the config.txt

			- If there are any spaces in the argument it will only read the part before the space. this 
		      includes anything within quotation marks. If there is a demand for a more robust config
			  it may be implemented in the future. 

			- Multiple instances can be running concurrently. This may cause an issue, as whichever instance
			  finds the switch first will send it's payload, which may not be the payload you intended to send.
			  This most likely won't be an issue if you plan on setting it up and not messing with it.

		The application will add itself to the windows startup registry. If you don't want it to start with
		windows, bring up task manager and disable TegraAutoSmash in the startup tab.
