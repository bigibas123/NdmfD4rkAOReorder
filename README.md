# D4rkAvatarOptimizer Reorderer

# <span style="color:red">Installing this package will make your d4rkAvatarOptimizer install unsupported, if you encounter any bugs try uninstalling this, restarting unity and checking if your still run into it.</span>

[VCC Repo](https://bigibas123.github.io/VCC/)

Tries to make running [d4rkAvatarOptimizer](https://github.com/d4rkc0d3r/d4rkAvatarOptimizer) with [NDMF](https://github.com/bdunderscore/ndmf.git) a bit more predictable.

It does this by removing the main d4rkAvatarOptimizer from the avatar building hooks and calling d4rkAvatarOptimizer at the end of the optimization step of NDMF instead.
This is done with reflection so I don't expect it to remain stable for longer periods of time.

If you have any sugestions about how to do it better I'm all ears or submit a pull request if you're able to.
