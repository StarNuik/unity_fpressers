#! /bin/bash

# local
me="[ send_build.sh ]"
sign="unity_fpressers_"
build_src="./Builds/fpressers/Build"

# remote
ssh_dest=`cat dest.secret | tr -d '\n'`
remote_dest="~/personal-cloud/static@root/Build"

hash=`tar c $build_src | md5sum | head -c 32`
tar="$sign$hash.tar"
local_tar="./Builds/$tar"
remote_tar="~/Artifacts/$tar"



if [ ! -f $local_tar ]
then
	echo "$me Packing build tar"
	tar -czvf $local_tar -C $build_src .
fi

echo "$me Testing whether the tar already exists on the remote"
if ! ssh $ssh_dest "test -e $remote_tar";
then
	echo "$me Sending build tar"
	scp $local_tar $ssh_dest:$remote_tar
fi

echo "$me Clearing remote build destination"
ssh -t $ssh_dest "rm -rf $remote_dest/*"

echo "$me Unpacking remote build tar"
ssh -t $ssh_dest "tar -xzvf $remote_tar -C $remote_dest"

echo "$me DONE"



