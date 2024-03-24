# What I learned

bt compression on nginx - a big no
nav agent fps movement - a big yes
global objects are still a r bad idea (SOs, ShaderSauceController)
timeline wants a reference - make a MB service, specifically for timelines
profiling webgl - impossible? (firefox + nsight graphics)
services - are still great
dot.names - kind of nice but rarely useful
	(only use - unity's object picker. which is big, but naming has to be consistent. no need for `Item.Type`, as UnityEngine.Object fields already cull by type. Use `Item.Parent's Name`, or mb `Item.Tag`)
	(BUT - `Item.Type` is sometimes really nice in the Hierarchy window, hmhm)
	(more than 1 .Tag or .Group is too much to process naturally)
	(as usual, its hard to guess what .Tag will be useful. Probably, don't use them on assets until you have a need)