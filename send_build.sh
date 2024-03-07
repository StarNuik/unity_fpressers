#! /bin/bash

# local
me="[ send_build.sh ]"
sign="build_fpressers_"
dir="./Builds"

# remote
dest=`cat dest.secret | tr -d '\n'`
remote_build="~/personal-cloud/static@root"

num=$1
if [ -z "$num" ]
then
	echo "$me No build num supplied."
	exit
fi

tar="$sign$num.tar"
local_build="$dir/$sign$num"
local_tar="$dir/$tar"

if [ ! -f $local_tar ]
then
	echo "$me Packing build tar"
	tar -czvf $local_tar -C $local_build .
fi

if ! ssh $dest "test -e ~/$tar";
then
	echo "$me Sending build tar"
	scp $local_tar $dest:~
fi

echo "$me Clearing remote build destination"
ssh -t $dest "rm -rf $remote_build/*"

echo "$me Unpacking remote build tar"
ssh -t $dest "tar -xzvf ~/$tar -C $remote_build"

echo "$me DONE"



