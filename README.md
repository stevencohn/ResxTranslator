# ResxTranslator
Automates the translation of resx files using throttled access to the Google Translation API in
an attempt to avoid the dreaded 403.

Inspired by https://github.com/salarcode/AutoResxTranslator

### Translate Resx File
Translate an entire .resx file to one or more languages.

1. Choose a .resx file to translate. It will detect the language based on the language/culture
   code in the filename. It will also remember the last file translated.
2. Choose the output directory where new .resx files should be stored. If this is left blank
   then new files are stored in the same directory as the source file.
3. Adjust the number of seconds to wait between each string translation. A number too low
   (somewhere less than 15 seconds) may cause Google to temporarily block with a 403 or 429
   error. When that happens, the translator will pause for 5 seconds and retry. Then it will
   pause for 10 seconds, 20, 30, 40, 50, and finally every 60 seconds for an hour before
   giving up.

Enable the _Translate only new strings_ checkbox to translate only new strings that were added
to the source resx file that are not yet in the target resx file(s). This looks for any
entries that have the keyword EDIT in its comment. This also remove items in the target
file(s) that were deleted in the source file.

Enable the _Clear markers_ checkbox to remove the EDIT keyword from all entires in the source
resx file. Do this only when processing the last target file in your workflow.

#### Language Selections

![Translate Resx](Images/LanguagesScreen.png)

#### Working

![Translate Resx](Images/TranslateResxScreen.png)

#### Skipping Resources

If the resource file includes control or configuration entries that should not be translated
then flag these by including the word **SKIP** in the entry's comment. It must be capitalized.
The comment can include other text besides the word SKIP.

### Translate Text
Translate one string, phrase, or paragraph of text.

![Translate Text](Images/TranslateTextScreen.png)

What's up with the _possible inflation detection_ message? Keep reading...


#### Inflation Detection

The free Google translator will sometime add extra spaces around non-alphanumeric characters
when translating. For example "x+1" may become "x + 1" (from no spaces around the plus sign,
to spaces around the plus sign.) 

ResxTranslator attempts to detect this string *inflation* and displays a warning for each
string that may need manual tuning. Of course, the program itself has no way of knowing the
exact context of the translation so it simply compare the number of spaces in the input
string and the output string. Most of the time, the translation is accurate and shouldn't need
to be adjusted manually.
