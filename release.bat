for /f "tokens=1* delims=" %%a in ('date /T') do set datestr=%%a
mkdir %datestr%