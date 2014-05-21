// function p(n) {
// 	function k(n){
// 		var c={},
//		n=Number(n);
// 		return n==0 ? 0.5 : c.n = (4 * n - 2) * k (n-1) / (n + 1);
// 	}
// 	return k(n);
// }

params = 7;

console.log(k("7"))

// function k(n){return (function k(n) {
// 	c={};
// 		if (n == 0) return 1;
// 		return c.n ? c.n : c.n = (4 * n - 2) * k(n-1) / (n+1);
// 	})()/2;
// }
//function k(e){c=[];if(e==0)return 1;return c[e]?c[e]:c[e]=(4*e-2)*k(e-1)/(e+1)}
//214.5

// (4*n-2)
// 2*(n-1)



// function k(n)
// {
// 	return (function k(n){return c={},0==n?1:c.n?c.n:c.n=(4*n-2)*k(n-1)/(n+1)})();
// }

//function t(n){function k(n){return c={},0==n?1:c.n?c.n:c.n=(4*n-2)*k(n-1)/(n+1)}return k(n)/2}  //<-----

//function k(n){return c={},0==n?1:c.n?c.n:c.n=(4*n-2)*k(n-1)/(n+1)}

function k(n){return c={},n=Number(n),0==n?.5:c.n=(4*n-2)*k(n-1)/(n+1)}
