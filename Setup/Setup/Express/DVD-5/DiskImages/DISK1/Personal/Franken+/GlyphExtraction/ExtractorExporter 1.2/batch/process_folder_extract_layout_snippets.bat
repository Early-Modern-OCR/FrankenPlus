@echo off
setlocal
::
:: Extracts region images for all documents in the SEARCH_PATH.
::
:: Adjust the following parameters as needed:
::

set SEARCH_PATH=.\Input\

set OUTPUT_PATH=Output

::
:: Autodetect Executable
::

FOR %%c in ("..\Extractor*.exe") DO (
 SET EXTRACTOR=%%c
)


@echo on

::
:: Loop through all files within the spceified folder
::

FOR %%c in ("%SEARCH_PATH%*.xml") DO (
  %EXTRACTOR% -extract layoutSnippets -filter-by type -filter text -page-content "%%c" -output-folder %OUTPUT_PATH%
)

endlocal