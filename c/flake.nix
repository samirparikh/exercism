{
  description = "C development environment";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";

  outputs = { self, nixpkgs }:
    let
      system = "x86_64-linux";
      pkgs = nixpkgs.legacyPackages.${system};
    in
    {
      devShells.${system}.default = (pkgs.mkShell.override {
        # Use clangStdenv to get proper NIX_CFLAGS_COMPILE environment variables
        stdenv = pkgs.clangStdenv;
      }) {
        packages = with pkgs; [
          # Clang toolchain (wrapped versions with proper Nix paths)
          clang-tools    # MUST come before clang - provides wrapped clangd
          clang          # C/C++ compiler
          
          # GCC toolchain (for when you want to use gcc instead)
          gcc
            
          # Build and debug tools
          gnumake
          gdb
          valgrind
          
          # Static analysis and formatting
          cppcheck
          indent
          clang-tools    # also provides clang-tidy and clang-format
          
          # LSP servers
          ccls           # works well with gcc
          # clangd is provided by clang-tools above
        ];

        shellHook = ''
          echo "C dev environment loaded"
          echo "gcc $(gcc --version | head -n1 | awk '{print $NF}')"
          echo "clang $(clang --version | head -n1 | awk '{print $NF}')"
          
          # Verify clangd is the wrapped version
          echo "clangd path: $(which clangd)"
        '';
      };
    };
}