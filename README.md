# WePayBinding

Xamarin Binding Project


Command line to generate ApiDefinition.cs

sharpie bind -output Binding -sdk iphoneos8.1 \
    -scope build/Headers build/Headers/POP/POP.h \
    -c -Ibuild/Headers -arch arm64
