@echo off
setlocal
::
:: Exports the text content on region level
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
  %EXTRACTOR% -export gamera -page-content "%%c" -image "%SEARCH_PATH%%%~nc.tif" -output-file %OUTPUT_PATH%\%%~nc.gamera.xml -param-file .\exporter_params.ini
)

endlocal