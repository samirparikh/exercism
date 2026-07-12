#!/usr/bin/env fish
# updatePackages.sh — Update .NET test package references and verify build/tests.
# Usage:
#   chmod +x updatePackages.sh
#   ./updatePackages.sh
#   # or run it from elsewhere:
#   ./updatePackages.sh /path/to/project

function die
    echo "ERROR: $argv" >&2
    exit 1
end

# Optional: allow passing the project directory as arg 1
set -l proj_dir (pwd)
if test (count $argv) -ge 1
    set proj_dir $argv[1]
end

cd $proj_dir; or die "Could not cd into '$proj_dir'"

# Ensure we're in a dotnet project folder (at least one *.fsproj)
set -l fsproj (ls *.fsproj ^/dev/null)
if test -z "$fsproj"
    die "No .fsproj found in '$proj_dir' (run inside the project directory or pass it as an argument)."
end

echo "==> Project dir: $proj_dir"
echo "==> Found: $fsproj"

# If there are multiple .fsproj files, dotnet add may need an explicit project.
# We'll default to the first one.
set -l project $fsproj[1]
echo "==> Using project: $project"

echo "==> Updating packages..."
dotnet add $project package Microsoft.NET.Test.Sdk --version 17.13.0; or die "Failed to add Microsoft.NET.Test.Sdk"
dotnet add $project package xunit --version 2.8.1; or die "Failed to add xunit"
dotnet add $project package xunit.runner.visualstudio --version 2.8.1; or die "Failed to add xunit.runner.visualstudio"
dotnet add $project package FsUnit.xUnit --version 6.0.0; or die "Failed to add FsUnit.xUnit"

echo "==> Restoring..."
dotnet restore; or die "dotnet restore failed"

echo "==> Building..."
dotnet build; or die "dotnet build failed"

echo "==> Testing..."
dotnet test; or die "dotnet test failed"

echo "==> Done. Packages updated and build/tests succeeded."
